// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

#nullable disable

using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace WariosWoodsEditor;

[DefaultProperty(nameof(Value))]
[DefaultEvent(nameof(ValueChanged))]
[DefaultBindingProperty(nameof(Value))]
public partial class HexBox : UpDownBase, ISupportInitialize {
	private const int DefaultValue = 0;
	private const int DefaultMinimum = 0;
	private const int DefaultMaximum = 255;
	private const int DefaultIncrement = 1;
	private const int InvalidValue = -1;

	/// <summary>
	///  The amount to increment by.
	/// </summary>
	private uint increment = DefaultIncrement;

	// Minimum and maximum values
	private uint minimum = DefaultMinimum;
	private uint maximum = DefaultMaximum;

	// Internal storage of the current value
	private uint currentValue = DefaultValue;
	private bool currentValueChanged;

	// Event handler for the onValueChanged event
	private EventHandler onValueChanged;

	// Disable value range checking while initializing the control
	private bool initializing;

	// Provides for finer acceleration behavior.
	private NumericUpDownAccelerationCollection accelerations;

	// the current NumericUpDownAcceleration object.
	private int accelerationsCurrentIndex;

	// Used to calculate the time elapsed since the up/down button was pressed,
	// to know when to get the next entry in the acceleration table.
	private long buttonPressedStartTime;

	public HexBox() : base() {
		StopAcceleration();
		Text = "00";
		TextAlign = HorizontalAlignment.Right;
	}

	//////////////////////////////////////////////////////////////
	// Properties
	//
	//////////////////////////////////////////////////////////////
	/// <summary>
	///  Specifies the acceleration information.
	/// </summary>
	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public NumericUpDownAccelerationCollection Accelerations  => accelerations ??= new NumericUpDownAccelerationCollection();

	public uint Increment {
		get {
			if (accelerationsCurrentIndex != InvalidValue) {
				return (uint) Accelerations[accelerationsCurrentIndex].Increment;
			}

			return increment;
		}

		set => increment = value;
	}


	[Browsable(false)]
	public int Digits { get; private set; } = 2;

	/// <summary>
	///  Gets or sets the maximum value for the up-down control.
	/// </summary>
	[RefreshProperties(RefreshProperties.All)]
	public uint Maximum {
		get => maximum;

		set {
			maximum = value;

			if (minimum > maximum) {
				minimum = maximum;
			}

			Digits = (int) Math.Log(Math.Max(1, maximum), 16) + 1;
			Value = Constrain(currentValue);

			Debug.Assert(maximum == value, "Maximum != what we just set it to!");
		}
	}

	/// <summary>
	///  Gets or sets the minimum allowed value for the up-down control.
	/// </summary>
	[RefreshProperties(RefreshProperties.All)]
	public uint Minimum {
		get => minimum;

		set {
			minimum = value;
			if (minimum > maximum) {
				maximum = value;
			}

			Value = Constrain(currentValue);
		}
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new Padding Padding {
		get => base.Padding;
		set => base.Padding = value;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	new public event EventHandler PaddingChanged {
		add => base.PaddingChanged += value;
		remove => base.PaddingChanged -= value;
	}

	/// <summary>
	///  Determines whether the UpDownButtons have been pressed for enough time to activate acceleration.
	/// </summary>
	private bool Spinning => accelerations is not null && buttonPressedStartTime != InvalidValue;

	/// <summary>
	///  The text displayed in the control.
	/// </summary>
	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Bindable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	// We're just overriding this to make it non-browsable.
	public override string Text {
		get => base.Text;
		set => base.Text = value;
	}

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	new public event EventHandler TextChanged {
		add => base.TextChanged += value;
		remove => base.TextChanged -= value;
	}

	/// <summary>
	///  Gets or sets the value
	///  assigned to the up-down control.
	/// </summary>
	[Bindable(true)]
	public uint Value {
		get {
			if (UserEdit) {
				ValidateEditText();
			}

			return currentValue;
		}

		set {
			if (value != currentValue) {
				if (!initializing && ((value < minimum) || (value > maximum))) {
					throw new ArgumentOutOfRangeException(nameof(value), value, "Ow");
				} else {
					currentValue = value;

					OnValueChanged(EventArgs.Empty);
					currentValueChanged = true;
					UpdateEditText();
				}
			}
		}
	}

	//////////////////////////////////////////////////////////////
	// Methods
	//
	//////////////////////////////////////////////////////////////
	/// <summary>
	///  Occurs when the <see cref='Value'/> property has been changed in some way.
	/// </summary>
	public event EventHandler ValueChanged {
		add => onValueChanged += value;
		remove => onValueChanged -= value;
	}

	/// <summary>
	///  Handles tasks required when the control is being initialized.
	/// </summary>
	public void BeginInit() {
		initializing = true;
	}

	//
	// Returns the provided value constrained to be within the min and max.
	//
	private uint Constrain(uint value) {
		if (value < minimum) {
			return minimum;
		}

		if (value > maximum) {
			return maximum;
		}

		return value;
	}

	/// <summary>
	///  Decrements the value of the up-down control.
	/// </summary>
	public override void DownButton() {
		SetNextAcceleration();

		if (UserEdit) {
			ParseEditText();
		}

		uint newValue = currentValue;

		try {
			checked {
				newValue -= Increment;

				if (newValue < minimum) {
					newValue = minimum;
					StopIfSpinning();
				}
			}
		} catch (OverflowException) {
			newValue = minimum;
			StopIfSpinning();
		}

		Value = newValue;
	}

	/// <summary>
	///  Called when initialization of the control is complete.
	/// </summary>
	public void EndInit() {
		initializing = false;
		Value = Constrain(currentValue);
		UpdateEditText();
	}

	/// <summary>
	///  Overridden to set/reset acceleration variables.
	/// </summary>
	protected override void OnKeyDown(KeyEventArgs e) {
		if (InterceptArrowKeys && (e.KeyCode is Keys.Up or Keys.Down) && !Spinning) {
			StartAcceleration();
		}

		base.OnKeyDown(e);
	}

	/// <summary>
	///  Overridden to set/reset acceleration variables.
	/// </summary>
	protected override void OnKeyUp(KeyEventArgs e) {
		if (InterceptArrowKeys && (e.KeyCode is Keys.Up or Keys.Down)) {
			StopAcceleration();
		}

		base.OnKeyUp(e);
	}

	protected override void OnTextBoxKeyPress(object source, KeyPressEventArgs e) {
		base.OnTextBoxKeyPress(source, e);

		if (char.IsDigit(e.KeyChar)) {
		} else if (e.KeyChar is '\b' or (>= 'a' and <= 'f') or (>= 'A' and <= 'F')) {
		} else if ((ModifierKeys & (Keys.Control | Keys.Alt)) != 0) {
		} else {
			e.Handled = true;
		}
	}

	/// <summary>
	///  Raises the <see cref='OnValueChanged'/> event.
	/// </summary>
	protected virtual void OnValueChanged(EventArgs e) {
		// Call the event handler
		onValueChanged?.Invoke(this, e);
	}

	protected override void OnLostFocus(EventArgs e) {
		base.OnLostFocus(e);
		if (UserEdit) {
			UpdateEditText();
		}
	}

	/// <summary>
	///  Converts the text displayed in the up-down control to a
	///  numeric value and evaluates it.
	/// </summary>
	protected void ParseEditText() {
		try {
			Value = Constrain(Convert.ToUInt32(Text, 16));
		} catch {
			// Leave value as it is
		} finally {
			UserEdit = false;
		}
	}

	/// <summary>
	///  Updates the index of the UpDownNumericAcceleration entry to use (if needed).
	/// </summary>
	private void SetNextAcceleration() {
		// Spinning will check if accelerations is null.
		if (Spinning && accelerationsCurrentIndex < (accelerations.Count - 1)) { // if index not the last entry ...
																				 // Ticks are in 100-nanoseconds (1E-7 seconds).
			long nowTicks = DateTime.Now.Ticks;
			long buttonPressedElapsedTime = nowTicks - buttonPressedStartTime;
			long accelerationInterval = 10000000L * accelerations[accelerationsCurrentIndex + 1].Seconds;  // next entry.

			// If Up/Down button pressed for more than the current acceleration entry interval, get next entry in the accel table.
			if (buttonPressedElapsedTime > accelerationInterval) {
				buttonPressedStartTime = nowTicks;
				accelerationsCurrentIndex++;
			}
		}
	}

	private void ResetIncrement() {
		Increment = DefaultIncrement;
	}

	private void ResetMaximum() {
		Maximum = DefaultMaximum;
	}

	private void ResetMinimum() {
		Minimum = DefaultMinimum;
	}

	private void ResetValue() {
		Value = DefaultValue;
	}

	/// <summary>
	///  Indicates whether the <see cref='Increment'/> property should be
	///  persisted.
	/// </summary>
	private bool ShouldSerializeIncrement() {
		return !Increment.Equals(DefaultIncrement);
	}

	/// <summary>
	///  Indicates whether the <see cref='Maximum'/> property should be persisted.
	/// </summary>
	private bool ShouldSerializeMaximum() {
		return !Maximum.Equals(DefaultMaximum);
	}

	/// <summary>
	///  Indicates whether the <see cref='Minimum'/> property should be persisted.
	/// </summary>
	private bool ShouldSerializeMinimum() {
		return !Minimum.Equals(DefaultMinimum);
	}

	/// <summary>
	///  Indicates whether the <see cref='Value'/> property should be persisted.
	/// </summary>
	private bool ShouldSerializeValue() {
		return !Value.Equals(DefaultValue);
	}

	/// <summary>
	///  Records when UpDownButtons are pressed to enable acceleration.
	/// </summary>
	private void StartAcceleration() {
		buttonPressedStartTime = DateTime.Now.Ticks;
	}

	/// <summary>
	///  Reset when UpDownButtons are pressed.
	/// </summary>
	private void StopAcceleration() {
		accelerationsCurrentIndex = InvalidValue;
		buttonPressedStartTime = InvalidValue;
	}

	/// <summary>
	///  Increments the value of the up-down control.
	/// </summary>
	public override void UpButton() {
		SetNextAcceleration();

		if (UserEdit) {
			ParseEditText();
		}

		uint newValue = currentValue;

		// Operations on Decimals can throw OverflowException.
		//
		try {
			checked {
				newValue += Increment;

				if (newValue > maximum) {
					newValue = maximum;
					StopIfSpinning();
				}
			}
			
		} catch (OverflowException) {
			newValue = maximum;
			StopIfSpinning();
		}

		Value = newValue;
	}

	private string GetNumberText(uint num) {
		return num.ToString($"X{Digits}", CultureInfo.InvariantCulture);
	}

	/// <summary>
	///  Displays the current value of the up-down control in the appropriate format.
	/// </summary>
	protected override void UpdateEditText() {
		// If we're initializing, we don't want to update the edit text yet,
		// just in case the value is invalid.
		if (initializing) {
			return;
		}

		// If the current value is user-edited, then parse this value before reformatting
		if (UserEdit) {
			ParseEditText();
		}

		if (currentValueChanged || (!string.IsNullOrEmpty(Text))) {
			currentValueChanged = false;
			ChangingText = true;

			Text = GetNumberText(currentValue);
		}
	}

	private void StopIfSpinning() {
		if (Spinning) {
			StopAcceleration();
		}
	}

	/// <summary>
	///  Validates and updates
	///  the text displayed in the up-down control.
	/// </summary>
	protected override void ValidateEditText() {
		ParseEditText();
		UpdateEditText();
	}
}
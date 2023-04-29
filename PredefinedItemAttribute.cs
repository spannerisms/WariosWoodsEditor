using System.Reflection;

namespace WariosWoodsEditor;

#nullable disable

/// <summary>
/// Marks static fields and properties that are to be discovered by reflection for listing.
/// </summary>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
internal sealed class PredefinedItemAttribute : Attribute { }

/// <summary>
/// Provides methods for using <see cref="PredefinedItemAttribute"/> to discover properties and fields.
/// </summary>
internal static class PredefinitionFunctions {
	/// <summary>
	/// Creates an <see cref="ImmutableArray{}"/> of all <typeparamref name="T"/> objects found within the class of <paramref name="parent"/>
	/// that are marked with the <see cref="PredefinedItemAttribute"/>.
	/// </summary>
	/// <param name="parent">The <see cref="Type"/> for the class containing the predefined items</param>
	public static ImmutableArray<T> GetListOfPredefinedFields<T>(Type parent) where T : class {
		return CreateListOfFields<T>(parent).ToImmutableArray();
	}

	/// <summary>
	/// Creates an <see cref="ImmutableArray{}"/> of all <typeparamref name="T"/> objects found within the class of <paramref name="parent"/>
	/// that are marked with the <see cref="PredefinedItemAttribute"/>, sorted according to the <see cref="Comparison{T}"/> passed.
	/// </summary>
	/// <param name="parent">The <see cref="Type"/> for the class containing the predefined items</param>
	/// <param name="sort">The <see cref="Comparison{T}"/> delegate </param>
	public static ImmutableArray<T> GetSortedListOfPredefinedFields<T>(Type parent, Comparison<T> sort) where T : class {
		var ret = CreateListOfFields<T>(parent);

		ret.Sort(sort);

		return ret.ToImmutableArray();
	}

	private static List<T> CreateListOfFields<T>(Type parent) where T : class {
		List<T> ret = new();

		var list = parent.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.ExactBinding);

		foreach (var o in list) {
			if (o.GetCustomAttribute(typeof(PredefinedItemAttribute)) is not null) {
				if (o.FieldType == typeof(T)) {
					ret.Add(o.GetValue(null) as T);
				}
			}
		}

		return ret;
	}
}
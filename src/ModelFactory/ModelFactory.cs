using System;
using System.Collections.Generic;

namespace Bytedecoder
{
  /// <summary>
  /// Allow the creation of models of tyep T based on Action delegates
  /// </summary>
  public class ModelFactory<T> where T : class, new()
  {
    /// <summary>
    /// Creates a model of type T defined by the modelBuilder 
    /// </summary>
    /// <param name="modelBuilder">Delegate that pass type T allowing the build of model properties</param>
    /// <returns>model of type T built</returns>
    public static T Create(Action<T> modelBuilder)
    {
      var model = new T();
      modelBuilder(model);
      return model;
    }

    /// <summary>
    /// Creates a sequence of models of type T defined by the modelBuilder 
    /// </summary>
    /// <param name="size">Number of elements in the output sequence</param>
    /// <param name="modelBuilder">Delegate that pass type T allowing the build of model properties</param>
    /// <returns></returns>
    public static IEnumerable<T> Create(int size, Action<T> modelBuilder)
    {
      var sequence = new T[size];

      for (var index = 0; index < size; index++)
      {
        sequence[index] = Create(modelBuilder);
      }

      return sequence;
    }
  }
}
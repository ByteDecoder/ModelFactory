namespace Bytedecoder
{
  public class ModelFactory
  {
    /// <summary>
    /// Creates a model of type T defined by the modelBuilder 
    /// </summary>
    /// <param name="modelBuilder">Delegate that pass type T allowing the build of model properties</param>
    /// <returns>model of type T builded</returns>
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
    public static IEnumerable<T> CreateSequence(int size, Action<T> modelBuilder)
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
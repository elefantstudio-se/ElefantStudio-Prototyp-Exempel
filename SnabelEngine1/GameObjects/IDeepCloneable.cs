
/// <summary>
/// An interface that allows deep cloning
/// </summary>
namespace Snabel_Engine
{
    public interface IDeepCloneable
    {
        /// <summary>
        /// Creates and returns a deep copy of the current object
        /// </summary>
        /// <returns>A deep copy of the current object</returns>
        object Clone();
    }
}

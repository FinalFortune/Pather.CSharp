using System.Collections.Generic;
using System.Threading.Tasks;
using Pather.CSharp.PathElements;

namespace Pather.CSharp
{
    public interface IResolver
    {
        IList<IPathElementFactory> PathElementFactories { get; set; }

        IList<IPathElement> CreatePath(string path);
        /// <summary>
        /// Returns the object defined by the path elements.
        /// Any access exception (e.g. NullReference) is propagated.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pathElements"></param>
        /// <returns></returns>
        object Resolve(object target, IList<IPathElement> pathElements);

        Task<object> ResolveAsync(object target, IList<IPathElement> pathElements);

        /// <summary>
        /// Returns the object defined by the path.
        /// Any access exception (e.g. NullReference) is propagated.
        /// </summary>
        /// <param name="target"></param>
        /// <param name="path"></param>
        /// <returns></returns>

        Task<object> ResolveAsync(object target, string path);
        object Resolve(object target, string path);

        /// <summary>
        /// Returns null if any object in the path is null
        /// </summary>
        /// <param name="target"></param>
        /// <param name="pathElements"></param>
        /// <returns></returns>
        object ResolveSafe(object target, IList<IPathElement> pathElements);

        /// <summary>
        /// Returns null if any object in the path is null
        /// </summary>
        /// <param name="target"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        object ResolveSafe(object target, string path);
    }
}
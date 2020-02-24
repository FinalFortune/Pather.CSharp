using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pather.CSharp.PathElements
{
    public abstract class PathElementBase : IPathElement
    {
        public IEnumerable Apply(Selection target)
        {
            var results = new List<object>();
            foreach (var entry in target.Entries)
            {
                results.Add(Apply(entry));
            }
            var result = new Selection(results);
            return result;
        }

        public abstract object Apply(object target);

        public async Task<IEnumerable> ApplyAsync(Selection target)
        {
            var results = new List<object>();
            foreach (var entry in target.Entries)
            {
                results.Add(await ApplyAsync(entry).ConfigureAwait(false));
            }
            var result = new Selection(results);
            return result;
        }

        public virtual Task<object> ApplyAsync(object target)
        {
            return Task.FromResult(Apply(target));
        }
    }
}

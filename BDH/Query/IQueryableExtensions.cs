using BDH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.EntityFrameworkCore
{
    public static class IQueryableExtensions
    {
        public static async Task<IPagedList<T>> PageResultAsync<T>(this IQueryable<T> query, int page, int pageSize,CancellationToken cancellationToken=default)
        {
            var result = query.PageResult(page, pageSize);
            var data = await result.Queryable.ToListAsync(cancellationToken);
            return new PagedList<T>(data, result.CurrentPage, result.PageCount, result.PageSize, result.RowCount);
        }
    }
}

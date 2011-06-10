using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data.Services.Client;
using System.Linq;
using System.Windows;
using Caliburn.Micro;
using Action = System.Action;

namespace Silverlight_Client.Queries
{
    public abstract class DataContextQuery<TModel, TViewModel>
    {
        private readonly DataServiceContext _context;

        protected DataContextQuery(DataServiceContext context)
        {
            _context = context;
        }

        protected abstract IQueryable<TModel> BuildQuery(DataServiceContext context);
        protected abstract TViewModel Map(TModel model);

        public void Execute(BindableCollection<TViewModel> targetCollection, Action onQueryExecuted = null)
        {
            var q = BuildQuery(_context);

            ExecuteQuery(q, results => Deployment.Current.Dispatcher.BeginInvoke(delegate
            {
                targetCollection.AddRange(results.Select(Map));
                if (null != onQueryExecuted) onQueryExecuted();
            }));
        }

        protected void ExecuteQuery<T>(IQueryable<T> query, Action<IEnumerable<T>> resultCallback)
        {
            var dataQuery = query as DataServiceQuery<T>;

            dataQuery.BeginExecute(ar =>
            {
                try
                {
                    var result = dataQuery.EndExecute(ar);
                    Deployment.Current.Dispatcher.BeginInvoke(resultCallback, result);
                }
                catch(Exception ex)
                {
                    LogError(ex);
                }

            }, null);
        }

        private void LogError(Exception ex)
        {
            if(Debugger.IsAttached) Debugger.Break();
        }
    }
}
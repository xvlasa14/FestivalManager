using FestivalManager.App.ViewModels;
using FestivalManager.BL.Models;
using System;
using System.Runtime.CompilerServices;

namespace FestivalManager.App.Wrappers
{
    public abstract class ModelWrapper<T> : ViewModelBase, IModel
        where T : IModel
    {
        protected ModelWrapper(T model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            Model = model;
        }

        public Guid Id
        {
            get => GetValue<Guid>();
            set => SetValue(value);
        }

        public T Model { get; }

        protected TValue GetValue<TValue>([CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName ?? string.Empty);
            return (propertyInfo?.GetValue(Model) is TValue
                ? (TValue)propertyInfo.GetValue(Model)
                : default);
        }

        protected void SetValue<TValue>(TValue value, [CallerMemberName] string propertyName = null)
        {
            var propertyInfo = Model.GetType().GetProperty(propertyName ?? string.Empty);
            var currentValue = propertyInfo?.GetValue(Model);
            if (!Equals(currentValue, value))
            {
                propertyInfo?.SetValue(Model, value);
                OnPropertyChanged(propertyName);
            }
        }

    }
}

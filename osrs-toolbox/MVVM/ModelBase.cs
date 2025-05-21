namespace osrs_toolbox
{
    public abstract class ModelBase : PropertyChangedBase
    {
        public void SetProperty<T>(ref T storage, T value, string name)
        {
            if (storage == null)
                throw new InvalidCastException("osrs_toolbox.ModelBase.UpdateProperty\nStorage cannot be null.");
            if (value == null)
                throw new InvalidCastException("osrs_toolbox.ModelBase.UpdateProperty\nValue cannot be null.");
            if (storage.GetType() != value.GetType())
                throw new InvalidCastException("osrs_toolbox.ModelBase.UpdateProperty\nVariable type mismatch between storage and value.");
            storage = value;
            OnPropertyChanged(name);
        }
    }
}

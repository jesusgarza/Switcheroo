﻿namespace Switcheroo.Configuration
{
    using System.Configuration;

    /// <summary>
    /// A collection of feature toggles for configuraiton purposes.
    /// </summary>
    public class FeatureToggleCollection : ConfigurationElementCollection
    {
        /// <summary>
        /// Gets or sets a property, attribute, or child element of this configuration element.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The configuration at the specified index.</returns>
        public ToggleConfig this[int index]
        {
            get
            {
                return (ToggleConfig)BaseGet(index);
            }

            set
            {
                if (BaseGet(index) != null)
                {
                    BaseRemoveAt(index);
                }

                BaseAdd(index, value);
            }
        }

        /// <summary>
        /// Adds the specified service config.
        /// </summary>
        /// <param name="serviceConfig">The service config.</param>
        public void Add(ToggleConfig serviceConfig)
        {
            BaseAdd(serviceConfig);
        }

        /// <summary>
        /// Clears this instance.
        /// </summary>
        public void Clear()
        {
            BaseClear();
        }

        /// <summary>
        /// Removes the specified service config.
        /// </summary>
        /// <param name="serviceConfig">The service config.</param>
        public void Remove(ToggleConfig serviceConfig)
        {
            BaseRemove(serviceConfig.Name);
        }

        /// <summary>
        /// Removes the item at the specific index.
        /// </summary>
        /// <param name="index">The index.</param>
        public void RemoveAt(int index)
        {
            BaseRemoveAt(index);
        }

        /// <summary>
        /// Removes the item with the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        public void Remove(string name)
        {
            BaseRemove(name);
        }

        /// <summary>
        /// When overridden in a derived class, creates a new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </summary>
        /// <returns>
        /// A new <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ToggleConfig();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element when overridden in a derived class.
        /// </summary>
        /// <param name="element">The <see cref="T:System.Configuration.ConfigurationElement" /> to return the key for.</param>
        /// <returns>
        /// An <see cref="T:System.Object" /> that acts as the key for the specified <see cref="T:System.Configuration.ConfigurationElement" />.
        /// </returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ToggleConfig)element).Name;
        }
    }
}
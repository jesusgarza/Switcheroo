﻿namespace Switcheroo
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A configuration store for feature toggles that can be managed by name.
    /// </summary>
    public interface IFeatureConfiguration : IEnumerable<IFeatureToggle>
    {
        /// <summary>
        /// Adds the specified feature toggle.
        /// </summary>
        /// <param name="toggle">The toggle to add to this configuration.</param>
        /// <exception cref="ArgumentNullException">If <paramref name="toggle"></paramref> is <c>null</c>.</exception>
        void Add(IFeatureToggle toggle);

        /// <summary>
        /// Determines whether the feature toggle with the specified name is enabled.
        /// </summary>
        /// <param name="featureName">Name of the feature toggle.</param>
        /// <returns>
        ///   <c>true</c> if the feature toggle with the specified feature name is enabled; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">If <paramref name="featureName"></paramref> is <c>null</c>.</exception>
        bool IsEnabled(string featureName);

        /// <summary>
        /// Gets the feature toggle with the specified name.
        /// </summary>
        /// <param name="toggleName">Name of the feature toggle.</param>
        /// <returns>The feature toggle with the specified name, if found, else <c>null</c>.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="toggleName"></paramref> is <c>null</c>.</exception>
        IFeatureToggle Get(string toggleName);

        /// <summary>
        /// Clears this instance, removing all feature toggles from it.
        /// </summary>
        void Clear();

        /// <summary>
        /// Initializes the this configuration using the specified configuration action.
        /// </summary>
        /// <param name="configuration">The source of configuration.</param>
        void Initialize(Action<IConfigurationExpression> configuration);

        /// <summary>
        /// Diagnostics on what's currently contained in this configuration instance.
        /// </summary>
        /// <returns>A descriptive string on feature toggles contained in this instance.</returns>
        string WhatDoIHave();
    }
}

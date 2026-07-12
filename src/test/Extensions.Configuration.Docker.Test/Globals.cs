using System;
using System.Diagnostics.CodeAnalysis;

namespace Extensions.Configuration.Docker.Test
{
    /// <summary>
    /// Defines names of attributes applied to objects via TraitAttribute.
    /// </summary>
    record TestAttributeNames
    {
        public string Category { get; } = default!;
    }
}


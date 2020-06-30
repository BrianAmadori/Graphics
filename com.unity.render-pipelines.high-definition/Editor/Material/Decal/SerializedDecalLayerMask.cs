using System;
using JetBrains.Annotations;
using UnityEngine.Rendering.HighDefinition;

namespace UnityEditor.Rendering.HighDefinition
{
    /// <summary>
    ///     Serialized class for <see cref="DecalLayerMask" />.
    /// </summary>
    public struct SerializedDecalLayerMask
    {
        readonly SerializedProperty m_ValueProperty;
        readonly SerializedProperty m_RootProperty;

        /// <summary>
        ///     Instantiate a SerializedDecalLayerMask from a <paramref name="serializedProperty" />.
        /// </summary>
        /// <param name="serializedProperty">The serialized property to use.</param>
        /// <exception cref="ArgumentNullException">When the <paramref name="serializedProperty" /> is null.</exception>
        /// <exception cref="ArgumentException">
        ///     When the <see cref="DecalLayer" /> properties can't be found in
        ///     <paramref name="serializedProperty" />.
        /// </exception>
        public SerializedDecalLayerMask([NotNull] SerializedProperty serializedProperty)
        {
            m_RootProperty = serializedProperty;
            if (serializedProperty == null) throw new ArgumentNullException(nameof(serializedProperty));

            m_ValueProperty = serializedProperty.FindPropertyRelative("m_Value");
            if (m_ValueProperty == null) throw new ArgumentException("Can't find property 'm_Value'.");
        }

        /// <summary>
        ///     The underlying decal layer value.
        ///     If there are multiple different value for the serialized property, then it is value is undefined.
        /// </summary>
        public DecalLayerMask value
        {
            get => (DecalLayerMask)m_ValueProperty.intValue;
            set => m_ValueProperty.intValue = (int)value;
        }

        /// <summary>
        ///     Convert the <see cref="SerializedDecalLayerMask" /> to its root <see cref="SerializedProperty" />.
        /// </summary>
        /// <param name="v">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static explicit operator SerializedProperty(in SerializedDecalLayerMask v)
        {
            return v.m_RootProperty;
        }
    }
}

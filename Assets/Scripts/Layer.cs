//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Univa
{
    
    /// <summary>
    /// Use this type in place of layer names in code / scripts.
    /// </summary>
    /// <example>
    /// <code>
    /// if (other.gameObject.layer == Layer.Characters) {
    ///     Destroy(other.gameObject);
    /// }
    /// </code>
    /// </example>
    public sealed class Layer
    {
        public const int Default = 0;
        public const int TransparentFX = 1;
        public const int IgnoreRaycast = 2;
        public const int Water = 4;
        public const int UI = 5;
        public const int Cookie = 6;
        public const int TouchGround = 7;
        public const int Enemy = 8;
        public const int DevVisual = 9;
        public const int Placement = 10;
        /// <summary>
        /// Use this type in place of layer or layer mask values in code / scripts.
        /// </summary>
        /// <example>
        /// <code>
        /// if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hit, Mathf.Infinity, Layer.Mask.Characters | Layer.Mask.Water) {
        ///     Debug.Log("Did Hit");
        /// }
        /// </code>
        /// </example>
        public sealed class Mask
        {
            public const int Default = 1;
            public const int TransparentFX = 2;
            public const int IgnoreRaycast = 4;
            public const int Water = 16;
            public const int UI = 32;
            public const int Cookie = 64;
            public const int TouchGround = 128;
            public const int Enemy = 256;
            public const int DevVisual = 512;
            public const int Placement = 1024;
        }
    }
}

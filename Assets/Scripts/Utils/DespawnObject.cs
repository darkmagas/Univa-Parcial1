using UnityEngine;

namespace Magas.Utilities
{
    public record DespawnObject(GameObject Object) : ISignal;
}

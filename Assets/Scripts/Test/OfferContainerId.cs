namespace Scripts.Test
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Sirenix.OdinInspector;
    using UnityEngine;

#if UNITY_EDITOR
    using GameModules.EditorTools;
#endif

    [Serializable]
    [ValueDropdown("@Scripts.Test.OfferContainerId.GetOfferContainerIds()", IsUniqueList = true, DropdownTitle = "OfferContainer")]
    public partial struct OfferContainerId
    {
        [SerializeField]
        public int value;

        #region static editor data

        private static OfferContainerMap _map;

        public static IEnumerable<ValueDropdownItem<OfferContainerId>> GetOfferContainerIds()
        {
            #if UNITY_EDITOR
            _map ??= EditorTools.GetAsset<OfferContainerMap>();
            var types = _map;
            if (types == null)
            {
                yield return new ValueDropdownItem<OfferContainerId>()
                {
                    Text = "EMPTY",
                    Value = (OfferContainerId)0,
                };
                yield break;
            }

            foreach (var type in types.value.collection)
            {
                yield return new ValueDropdownItem<OfferContainerId>()
                {
                    Text = type.name,
                    Value = (OfferContainerId)type.id,
                };
            }
            #endif
            yield break;
        }

        public static string GetOfferContainerName(OfferContainerId id)
        {
#if UNITY_EDITOR
            var types = GetOfferContainerIds();
            var filteredTypes = types.FirstOrDefault(x => x.Value == id);
            var name = filteredTypes.Text;
            return string.IsNullOrEmpty(name) ? string.Empty : name;
#endif
            return string.Empty;
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Reset()
        {
            _map = null;
        }

        #endregion

        public static implicit operator int(OfferContainerId v) => v.value;
        public static explicit operator OfferContainerId(int v) => new OfferContainerId { value = v };
        public override string ToString() => value.ToString();
        public override int GetHashCode() => value;

        public OfferContainerId FromInt(int data)
        {
            value = data;
            return this;
        }

        public override bool Equals(object obj)
        {
            if (obj is OfferContainerId mask) return mask.value == value;
            return false;
        }
    }
}

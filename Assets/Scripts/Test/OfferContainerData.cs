namespace Scripts.Test
{
    using System;
    using System.Collections.Generic;
    using Sirenix.OdinInspector;

    [Serializable]
    public class OfferContainerData
    {
        [InlineProperty]
        public List<OfferContainer> collection = new List<OfferContainer>();
    }
}

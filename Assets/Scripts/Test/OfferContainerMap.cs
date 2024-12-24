namespace Scripts.Test
{
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Text;
    using Sirenix.OdinInspector;
    using UnityEngine;

#if UNITY_EDITOR
    using UnityEditor;
#endif

    [CreateAssetMenu(menuName = "Game/Maps/OfferContainer Map", fileName = "OfferContainer Map")]
    public class OfferContainerMap : ScriptableObject
    {
        [InlineProperty]
        [HideLabel]
        public OfferContainerData value = new OfferContainerData();

        #region IdGenerator

#if UNITY_EDITOR
        [Button("Generate Static Properties")]
        public void GenerateProperties()
        {
            GenerateStaticProperties(this);
        }

        public static void GenerateStaticProperties(OfferContainerMap map)
        {
            var idType = typeof(OfferContainerId);
            var idTypeName = nameof(OfferContainerId);
            var scriptPath = AssetDatabase.GetAssetPath(MonoScript.FromScriptableObject(map));
            var directoryPath = Path.GetDirectoryName(scriptPath);
            var outputPath = Path.Combine(directoryPath, "Generated");
            var outputFileName = $"{idTypeName}.Generated.cs";

            if (!Directory.Exists(outputPath))
            {
                Directory.CreateDirectory(outputPath);
            }

            var namespaceName = idType.Namespace;
            var filePath = Path.Combine(outputPath, outputFileName);

            using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"namespace {namespaceName}");
                writer.WriteLine("{");
                writer.WriteLine($"    public partial struct {idTypeName}");
                writer.WriteLine("    {");

                var typesField = typeof(OfferContainerData)
                    .GetField("collection", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                if (typesField != null)
                {
                    var types = (List<OfferContainer>)typesField.GetValue(map.value);
                    foreach (var type in types)
                    {
                        var propertyName = type.name.Replace(" ", "");
                        writer.WriteLine($"        public static {idTypeName} {propertyName} = new {idTypeName} {{ value = {type.id} }};");
                    }
                }

                writer.WriteLine("    }");
                writer.WriteLine("}");
            }

            AssetDatabase.Refresh();
            Debug.Log("Partial class with static properties generated successfully.");
        }
#endif

        #endregion
    }
}

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Quest_for_a_Kingdom
{
    class SaveAndLoadData
    {
        public static void SaveData(SaveFileDialog saveDialog, PersistDataContainer saveItems)
        {
            string fileName = saveDialog.FileName;
            Stream fileStream = File.Create(fileName);
            BinaryFormatter serializer = new BinaryFormatter();
            serializer.Serialize(fileStream, saveItems);
            fileStream.Close();
        }

        public static PersistDataContainer LoadData(OpenFileDialog loadFile, string fileName)
        {
            PersistDataContainer loadItems = new PersistDataContainer();
            Stream fileStream = File.OpenRead(fileName);
            BinaryFormatter deserializer = new BinaryFormatter();
            loadItems = (PersistDataContainer)deserializer.Deserialize(fileStream);
            fileStream.Close();

            return loadItems;
        }
    }
}

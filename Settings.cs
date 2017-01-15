using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace MBS
{
    class Settings
    {
        private static string SettingsFile = "X.MLB";

		public string Homepage { get; set; }

		public bool exists()
		{
			return (File.Exists(SettingsFile)) ? true : false;
		}

		public void create()
		{
            this.Homepage = "http://www.menglolita.com/X.html";
		}

		public void load()
		{
			using(var reader = new StreamReader(File.Open(SettingsFile, FileMode.Open, FileAccess.Read)))
			{
				var json = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(reader.ReadToEnd());

				this.Homepage = json["MLBXhomepage"];
			}
		}

		public void save()
		{
			if (exists()) File.Delete(SettingsFile);

			using(var writer = new StreamWriter(File.Open(SettingsFile, FileMode.OpenOrCreate, FileAccess.Write)))
			{
				var json = new JavaScriptSerializer().Serialize(new
					{
						MLBXhomepage = this.Homepage,
                        MLBXversion = "MBS 1.0 beta",
                        MLBXPS = "此配置文件为浏览器配置"
					});

				writer.Write(json);
			}
		}
    }
}

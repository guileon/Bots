using UnityEngine;
using System.Collections;
using TiledSharp;
using System.Collections.Generic;
public class MapReader : MonoBehaviour {

	void Start () {
		Dictionary<int, string> terrainDict = new Dictionary<int, string>();
		var map = new TmxMap("Assets/Resources/Maps/sample.tmx");
		TmxList<TmxLayer> layers = map.Layers;

		//Creating the terrain dictionary
		int tilesetNumber = 0;
		var terrains = map.Tilesets[tilesetNumber].Terrains;
		int firstGid = map.Tilesets [tilesetNumber].FirstGid;
		foreach (var t in terrains) {
			terrainDict.Add (t.Tile+firstGid, t.Name);
		}
		foreach (KeyValuePair<int, string> bla in terrainDict)
			Debug.Log (bla.Key.ToString() + " " + bla.Value);


		//Placing the prefabs in the world
		foreach (var layer in map.Layers) {
			foreach (var tile in layer.Tiles) {
				string name;
				if (terrainDict.TryGetValue (tile.Gid, out name)) {
					Object test = Resources.Load ("Prefabs/" + name);
					Instantiate (test, new Vector3 (tile.X, 0.5f, tile.Y), Quaternion.identity);
				} else
					Debug.Log (tile.Gid);
			}
		}




	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

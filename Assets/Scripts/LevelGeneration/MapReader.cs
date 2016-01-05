using UnityEngine;
using System.Collections;
using TiledSharp;
using System.Collections.Generic;
public class MapReader : MonoBehaviour {
	public TmxMap map = new TmxMap("Assets/Resources/Maps/sample.tmx");

	void Start () {
		var terrainDict = createTerrainDict(map.Tilesets);

		TmxList<TmxLayer> layers = map.Layers;
		foreach (var layer in map.Layers) {
			drawLayer (layer, terrainDict);
		}
	}

	/* creates dictionary for tiles */
	private Dictionary<int, string> createTerrainDict(TmxList<TmxTileset> sets) {
		Dictionary<int, string> tdict = new Dictionary<int, string>();

		foreach (var set in sets) {
			var firstGid = set.FirstGid;
			foreach (var terrain in set.Terrains) {
				tdict.Add (terrain.Tile + firstGid, terrain.Name);
			}
		}

		return tdict;
	}

	/* draws layers */
	private void drawLayer(TmxLayer layer, Dictionary<int, string> terrainDict) {
		foreach (var tile in layer.Tiles) {
			string name;
			if (terrainDict.TryGetValue (tile.Gid, out name)) {
				Object test = Resources.Load ("Prefabs/" + name);
				Instantiate (test, new Vector3 (tile.X, 0.5f, tile.Y), Quaternion.identity);
			} else
				Debug.Log (tile.Gid);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

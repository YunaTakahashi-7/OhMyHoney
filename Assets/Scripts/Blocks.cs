using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Blocks
{
	public class BlockObj
	{
		public BlockObj(int x, int z, GameObject b)
		{
			this.X = x;
			this.Z = z;
			this.Block = b;
		}
		public int X { get; private set; }
		public int Z { get; private set; }
		public GameObject Block { get; set; }
	}

	GameObject prefab;
	Transform floor;
	int width;
	int height;
	BlockObj[] blocks; 
	int[] map; 
	bool remap;
	Vector3 blockSize;
	string prefsName;

	public Blocks(GameObject prefab, Transform floor, int dx, int dz, string prefsName)
	{
		this.prefab = prefab;
		this.floor = floor;
		this.width = dx;
		this.height = dz;
		this.prefsName = prefsName;
		this.blockSize = prefab.GetComponent<Transform>().localScale;

		blocks = new BlockObj[width * height]; //参照型の変数宣言 newするものは参照型
		map = new int[blocks.Length]; // 参照型の変数宣言 newするものは参照型
		foreach (var item in blocks.Select((v, i) => new { v, i }))
		{
			blocks[item.i] = new BlockObj(i2x(item.i), i2z(item.i), null);
		}
	}

	public void Init(Dictionary<string, int[]> objPositions)
	{
		// 文字列として保存していたブロックの位置データを配列として読み出す
		int[] mapv = PlayerPrefs.GetString(prefsName).Split(',').Where(s => s.Length != 0).Select(s => int.Parse(s)).ToArray();
		// 読み込んだ配列を
		foreach (var item in blocks.Select((v, i) => new { v, i }))
		{
			int x = i2x(item.i);
			int z = i2z(item.i);

			// Any（Linq）でobjPositionsとかぶっているものがあるかをチェックする
			bool b0 = objPositions.Any(i => i.Value[0] == x && i.Value[1] == z) == false;
			bool b1 = b0 && (item.i < mapv.Length ? mapv[item.i] == -1 : false);
			if (b1)
			{
				//CreateBlock(x, z); あとでもどす！！
			}
		}
	}

	public int i2x(int i)
	{
		return i % width;
	}
	public int i2z(int i)
	{
		return i / width;
	}
	public int[] i2xz(int i)
	{
		return new int[] { i2x(i), i2z(i) };
	}
	public int xz2i(int[] xz)
	{
		return xz2i(xz[0], xz[1]);
	}
	public int xz2i(int x, int z)
	{
		return x + z * width;
	}
}

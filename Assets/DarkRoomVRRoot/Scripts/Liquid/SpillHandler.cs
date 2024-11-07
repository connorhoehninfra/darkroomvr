using UnityEngine;
using System.Collections;

/// <summary>
/// Shows the spill point on the glass when it's rotated.
/// </summary>
namespace LiquidVolumeFX
{
	public class SpillHandler : MonoBehaviour
	{

		public GameObject spill;

		LiquidVolume lv;
		GameObject[] dropTemplates;
		const int DROP_TEMPLATES_COUNT = 10;

		void Start()
		{
			lv = GetComponent<LiquidVolume>();

			dropTemplates = new GameObject[DROP_TEMPLATES_COUNT];
			for (int k = 0; k < DROP_TEMPLATES_COUNT; k++)
			{
				GameObject oneSpill = Instantiate(spill) as GameObject;
				oneSpill.transform.localScale *= Random.Range(0.45f, 0.65f);
				oneSpill.GetComponent<Renderer>().material.color = Color.Lerp(lv.liquidColor1, lv.liquidColor2, Random.value);
				oneSpill.SetActive(false);
				dropTemplates[k] = oneSpill;
			}
		}



		void FixedUpdate()
		{

			Vector3 spillPos;
			float spillAmount;
			if (lv.GetSpillPoint(out spillPos, out spillAmount))
			{
				const int drops = 15;
				for (int k = 0; k < drops; k++)
				{
					int template = Random.Range(0, DROP_TEMPLATES_COUNT);
					GameObject oneSpill = Instantiate(dropTemplates[template]) as GameObject;
					oneSpill.SetActive(true);
					Rigidbody rb = oneSpill.GetComponent<Rigidbody>();
					rb.transform.position = spillPos + Random.insideUnitSphere * 0.01f;
					rb.AddForce(new Vector3(Random.value - 0.5f, Random.value * 0.1f - 0.2f, Random.value - 0.5f));
				}
				lv.level -= spillAmount / 10f + 0.001f;
			}
		}


	}
}

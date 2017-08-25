using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattlePreparationUI : MonoBehaviour 
{
    public int columns;
    public int rows;
    public int attackSlotCount;
    public int passiveSlotCount;
    public Image equipmentBlock;

	// Use this for initialization
	void Start () 
    {
        CreateEquipmentBox();
        CreateAttackSlots();
        CreatePassiveSlots();
	}
	
	void CreateEquipmentBox()
    {
        for(int a = 0; a < rows; a++)
        {
            for(int b = 0; b < columns; b++)
            {
                Image equipmentBlockClone = equipmentBlock;
                equipmentBlockClone = Instantiate(equipmentBlock, new Vector3((3f * b + equipmentBlock.transform.position.x - equipmentBlock.GetComponent<RectTransform>().rect.width * b), equipmentBlock.transform.position.y - equipmentBlock.GetComponent<RectTransform>().rect.height * a + 3f * a, equipmentBlock.transform.position.z), equipmentBlock.transform.rotation) as Image;
                equipmentBlockClone.transform.SetParent(transform, false);
            }
        }
    }

    void CreateAttackSlots()
    {
        int equipedRows = (int)Mathf.Ceil((float)attackSlotCount / (float)columns);
        int addedCount = 0;

        for(int a = 0; a < equipedRows; a++)
        {
            for(int b = 0; b < columns; b++)
            {
                if(addedCount == attackSlotCount)
                {
                    break;
                }

                Image equipmentBlockClone = equipmentBlock;
                Vector2 startingPos = new Vector2(40f, equipmentBlock.transform.position.y - 60);
                equipmentBlockClone = Instantiate(equipmentBlock, new Vector3((startingPos.x + equipmentBlock.GetComponent<RectTransform>().rect.width * b - 3f * b), startingPos.y - equipmentBlock.GetComponent<RectTransform>().rect.height * a + 3f * a, equipmentBlock.transform.position.z), equipmentBlock.transform.rotation) as Image;
                equipmentBlockClone.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
                equipmentBlockClone.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
                equipmentBlockClone.transform.SetParent(transform, false);
                addedCount++;
            }
        }
    }

    void CreatePassiveSlots()
    {
        int equipedRows = (int)Mathf.Ceil((float)passiveSlotCount / (float)columns);
        int addedCount = 0;

        for (int a = 0; a < equipedRows; a++)
        {
            for (int b = 0; b < columns; b++)
            {
                if (addedCount == passiveSlotCount)
                {
                    break;
                }

                Image equipmentBlockClone = equipmentBlock;
                Vector2 startingPos = new Vector2(40f, equipmentBlock.transform.position.y - 150);
                equipmentBlockClone = Instantiate(equipmentBlock, new Vector3((startingPos.x + equipmentBlock.GetComponent<RectTransform>().rect.width * b - 3f * b), startingPos.y - equipmentBlock.GetComponent<RectTransform>().rect.height * a + 3f * a, equipmentBlock.transform.position.z), equipmentBlock.transform.rotation) as Image;
                equipmentBlockClone.GetComponent<RectTransform>().anchorMin = new Vector2(0f, 1f);
                equipmentBlockClone.GetComponent<RectTransform>().anchorMax = new Vector2(0f, 1f);
                equipmentBlockClone.transform.SetParent(transform, false);
                addedCount++;
            }
        }
    }

}

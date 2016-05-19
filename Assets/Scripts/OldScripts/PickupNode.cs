using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class PickupNode : MonoBehaviour {
	
    // private fields
	private ArrayList myProps = new ArrayList();
	private ArrayList myItems = new ArrayList();
	private float totalAtk;
	private float totalDef;

	//Getters
    // private fields

    public Transform getTransform() {
        return this.transform;
    }

	public float getNodeAtk(){
		return totalAtk;
	}

	public float getNodeDef(){
		return totalDef;
	}

	public ArrayList getNodeProps(){
		return myProps;
	}

	public ArrayList getNodeItems(){
		return myItems;
	}

	//Setters
    public void setPosition(Transform t) {
        this.transform.position = t.position;
    }

	public void updateAtk(float val){
		totalAtk = val;
	}

	public void updateDef(float val){
		totalDef = val;
	}

	public void updateProps(ArrayList props){
		foreach(var element in props){
			if (!myProps.Contains (element)) {
				myProps.Add (element);
			}
		}
	}

	public void updateItems(PickupProperties item){
		
		myItems.Add (item);
        updateAtk(getNodeAtk() + item.attackModifier());
        updateDef(getNodeDef() + item.defenseModifier());

    }

	public void effectItemsDur() {

		for(int i = 0; i < myItems.Count; i++) {
			PickupProperties curr_item = (PickupProperties)myItems [i];
			curr_item.useDurability ();
			if (curr_item.durability () <= 0) {
				updateAtk (getNodeAtk () - curr_item.attackModifier ());
				updateDef (getNodeDef () - curr_item.defenseModifier ());
				Destroy (curr_item.gameObject);
				myItems.Remove (curr_item);
			}
		}
	}

    public void printMe() {

        print("This Node you just appended to's values\n"
               + "Attack: " + getNodeAtk() + " "
               + "Defense: " + getNodeDef() + "\n"
               ) ;

    }
}
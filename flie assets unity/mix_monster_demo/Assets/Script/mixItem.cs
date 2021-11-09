using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mixItem : MonoBehaviour
{
    public List<dataGene> dad = new List<dataGene>();
    public List<dataGene> mom = new List<dataGene>();
    private int valueComponent;

    void Start(){
        print(component());
        valueComponent = component();
    }
    // void Update(){}
    int component(){ //check value  component dad && mom
        int n;
        if(dad.Count > mom.Count){
            n = dad.Count;
        }
        else if(dad.Count < mom.Count){
            n = mom.Count;
        }
        else{
            n = dad.Count;
        }
        return n;
    }
    public void mixGene(){ //order create 
         for (int i = 0; i < valueComponent; i++){
            if(dad.Count >= i && mom.Count >= i ){
                bool inherit = random_breeder();
                if(inherit == true){
                    if(i < dad.Count){
                        switch(checkGene(random_Percenr())){
                            case 0: FindObjectOfType<managerUI>().txt_stetus[i].text = dad[i].name+": " + dad[i].Deminant + "   <= Gene Deminant from dad".ToString();
                            break;
                            case 1: FindObjectOfType<managerUI>().txt_stetus[i].text = dad[i].name+": " + dad[i].Recessive + "   <= Gene Recessive from dad".ToString();
                            break;
                            case 2: FindObjectOfType<managerUI>().txt_stetus[i].text = dad[i].name+": " + dad[i].MinorRecessive + "   <= Gene MinorRecessive from dad".ToString();
                            break;
                        }     
                    }
                    else{
                        FindObjectOfType<managerUI>().txt_stetus[i].text = "null".ToString();
                    }
                    print("dad : "+i +": "+ mom[i].name);
                }
                else{
                    if( i < mom.Count){
                        switch(checkGene(random_Percenr())){
                            case 0: FindObjectOfType<managerUI>().txt_stetus[i].text = mom[i].name + ": " + mom[i].Deminant + "   <= Gene Deminant from mom".ToString();
                            break;
                            case 1: FindObjectOfType<managerUI>().txt_stetus[i].text = mom[i].name + ": " + mom[i].Recessive + "   <= Gene Recessive from mom".ToString();
                            break;
                            case 2: FindObjectOfType<managerUI>().txt_stetus[i].text = mom[i].name + ": " + mom[i].MinorRecessive + "   <= Gene MinorRecessive from mom".ToString();
                            break;
                        }
                    }
                    else{
                      FindObjectOfType<managerUI>().txt_stetus[i].text = "null".ToString();  
                    }
                    print("mom : "+i +": "+ mom[i].name);
                }
            }
        }
    }

    bool random_breeder(){ //random gene dad && mom
        bool s = Random.Range(0,2) !=0;
        return s;
    }

    int checkGene(float _p){ //check level gene  
        int nP;
        if(_p <= 0.375f){   //0 ->  0.375 = 0.375% /0.5
            nP = 0;
        }
        else if(_p <= 0.46875f){  //0.375 -> 0.46875f = 9.375%/0.5
            nP = 1;
        }
        else{                      // != 0 -> 0.46875   = 3.125% /0.5
            nP = 2;
        }
        return nP;
    }

    float random_Percenr(){ //random level gene
        float percenr = Random.value/2; //  float max = 1 /2 = 0.5
        return percenr;
    }
}

[System.Serializable]
public class dataGene{
    public string name;
    public string Deminant;
    public string Recessive;
    public string MinorRecessive;
}
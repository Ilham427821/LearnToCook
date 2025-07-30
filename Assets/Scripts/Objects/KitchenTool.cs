using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum KitchenTools {
    NONE, PAN, POT, MIXER // ✅ Tambahkan MIXER di sini
};

public class KitchenTool : Object {
    public KitchenTools tool;
    private Ingredient ingredient;
    private ParticleSystem smoke;

    public void Start() {
        smoke = transform.GetChild(1).GetComponent<ParticleSystem>();
    }

    public void Update() {
        if(HasIngredient()) {
            if(smoke != null && !smoke.isPlaying)
                smoke.Play();
        } else if (smoke != null)
            smoke.Stop();
    }

    public bool Cook() {
        if(ingredient != null)
            return ingredient.Cook();
        return true;
    }

    public bool HasIngredient(){
        return ingredient != null;
    }

    public override void Burn(){
        if(ingredient != null)
            ingredient.Burn();
    }

    public bool AddIngredient(Ingredient ingredient) {
        if(this.ingredient == null && IsValid(ingredient)) {
            ingredient.transform.SetParent(transform.GetChild(0));

            // ✅ Posisi berdasarkan alat
            switch (tool) {
                case KitchenTools.PAN:
                    ingredient.transform.localPosition = new Vector3(0.0f, 0.0f, 0.005f);
                    break;
                case KitchenTools.MIXER:
                    ingredient.transform.localPosition = new Vector3(0.0f, 0.0f, 0.01f); // bisa disesuaikan
                    break;
                default:
                    ingredient.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
                    break;
            }

            this.ingredient = ingredient;
            return true;
        } else
            return false;
    }

    private bool IsValid(Ingredient ingredient) {
        // ✅ Tambahkan pengecekan khusus mixer
        bool validState = 
            (ingredient.choppable && ingredient.GetState() == State.CHOPPED) || 
            (!ingredient.choppable && ingredient.GetState() == State.RAW);

        if (tool == KitchenTools.MIXER) {
            return ingredient.kitchenTool == KitchenTools.MIXER && validState;
        }

        return ingredient.cookable && ingredient.kitchenTool == this.tool && validState;
    }

    public Ingredient GetIngredient(){
        return ingredient;
    }

    public void DeleteIngredient(){
        ingredient = null;
    }

    override public void ThrowToBin() {
        if(ingredient != null) {
            Destroy(ingredient.gameObject);
            ingredient = null;
        }
    }
}

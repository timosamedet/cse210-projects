using System;

public class Scripture{

    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(){

    }

    public Scripture(Reference reference, string text){
        string[] words = text.Split(" ");
        
        foreach(string wordText in words){
            Word word = new Word(wordText);
            _words.Add(word);
        }

    }

    public void HideRandomWords(int numberToHide ){

    }

    public string GetDisplayText(){
        return "";
    }

    public bool IsCompletelyHidden(){
        return false;
    }

}
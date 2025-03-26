using System;
using System.Security.Cryptography;

public class Scripture{

    private Reference _reference;
    private List<Word> _words = new List<Word>();
    private int _hideCount = 0;
    private List<int> _randomWordsIndicesToHide = new List<int>();

    public Scripture(){

    }

    public Scripture(Reference reference, string text){
        string[] words = text.Split(" ");

        foreach(string wordText in words){
            Word word = new Word(wordText);
            _words.Add(word);
        }
        _reference = reference;
        generateRandomWordIndicesToHide();
    }

    public void HideRandomWords(int numberToHide ){
        _hideCount += numberToHide;
    
        for(int i = 1; i <= numberToHide; i++){
            if(_hideCount > _words.Count()){
               int difference = numberToHide -(_hideCount - _words.Count());
                if(difference <= 0) {
                    break;
                }
                numberToHide = difference;
                _hideCount = _words.Count();
            }

           int randomIndex = _randomWordsIndicesToHide[_hideCount - i];
           _words[randomIndex].Hide();
        }
    }

    public string GetDisplayText(){
        string text = "";
        foreach(Word word in _words){
            text = text + $"{word.GetDisplayText()} ";
        }
        return $"{_reference.GetDisplayText()} {text}\n";
    }

    public bool IsCompletelyHidden(){
        if(_hideCount == _words.Count())
        {
            return true;
        }
        return false;
    }


    public List<int> generateRandomWordIndicesToHide(){
        int min = 0;
        int max = _words.Count();

        for(int i = min; i < max; i++){
            _randomWordsIndicesToHide.Add(i);
        }

        Random random = new Random();
        for(int i = _randomWordsIndicesToHide.Count() - 1; i >= 0; i-- ){

            int j = random.Next(min, max);
            int temp = _randomWordsIndicesToHide[i];
            _randomWordsIndicesToHide[i] = _randomWordsIndicesToHide[j];
            _randomWordsIndicesToHide[j] = temp;
        }

        return _randomWordsIndicesToHide;
    }
}
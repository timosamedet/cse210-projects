using System;

public class Comment{

    private string _commentor;
    private string _text;


    public Comment(string commentor, string text){
        this._commentor = commentor;
        this._text = text;
    }

    public string GetCommentor(){
        return this._commentor;
    }

    public string GetText(){
        return this._text;
    }
}
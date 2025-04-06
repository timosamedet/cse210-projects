using System;
using System.Collections.Generic;

public class Video{

    private string _title;

    private string _author;

    private long _length;

    private List<Comment> _comments = new List<Comment>();


    public Video(string title, string author, long length, List<Comment> comments){
        this._title = title;
        this._author = author;
        this._length = length;
        this._comments = comments;
    }

    public string GetTitle(){
        return this._title;
    }

    public string GetAuthor(){
        return this._author;
    }

    public long GetLength(){
        return this._length;
    }

    public List<string> GetComments(){
        List<string> comments = new List<string>();

        foreach(Comment comment in _comments){
            comments.Add($"{comment.GetText()} --- {comment.GetCommentor()}");
        }
        return comments;
    }

    public int GetNumberOfComments(){
        return _comments.Count();
    }

}
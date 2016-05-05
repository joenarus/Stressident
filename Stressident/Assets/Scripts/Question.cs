using UnityEngine;
using System.Collections;

public class Question {

	private int yes;
	private int no;
	private int hold;
	private string qquestion;
	public string topic;
	private bool answered;
	private int answeredVal;

	public Question(string _question, string _topic, int _yes, int _no, int _hold) {
		this.qquestion = _question;
		this.yes = _yes;
		this.no = _no;
		this.hold = _hold;
		this.topic = _topic;
		answered = false;
	}

	public string Qquestion {
		get {
			return qquestion;
		}
		set { qquestion = value;
		}
	}
	public int Yes {
		get {
			return yes;
		}
	}

	public int No {
		get {
			return no;
		}
	}

	public int Hold {
		get {
			return hold;
		}
	}

	public bool Answered {
		get {
			return answered;
		}
		set {
			answered = value;
		}
	}

	public int AnsweredValue {
		get {
			return answeredVal;
		}
		set {
			answeredVal = value;
		}
	}


}

import './App.css';
import React from 'react';

export default class App extends React.Component {
  state = {
    'allQuestions': [], 
    'question': null, 
    'numberOfQuestions': 0,
    'correct': 0,
    'done': false, 
    'alternatives': [],
    'checkboxValues': [
      {'checked': false, 'correctAnswer': null}, 
      {'checked': false, 'correctAnswer': null}, 
      {'checked': false, 'correctAnswer': null}
    ]
  };

  constructor(props) {
    super(props);
    this.submit = this.submit.bind(this);
  } 

  async componentDidMount() {
    await this.getAllQuestions();
    this.getNextQuestion();
  } 
  
  async getAllQuestions() {
    await fetch('https://localhost:7043/Question/GetAll')
      .then(response => response.json()) 
      .then(data => {
        this.setState({'allQuestions': data});
        this.setState({'numberOfQuestions': data.length});
      });
  }
 
  getNextQuestion() {
    var question = {...this.state.allQuestions.pop()};
    
    // Workaround: Prevents first question from appearing twice 
    if (this.state.question && question?.question === this.state.question.question) {
      question = {...this.state.allQuestions.pop()};
    }

    this.setState({'question': question}); 
    this.setState({'alternatives': question.alternatives});
    if (this.state.question == null) {
      this.setState({'done': true});
    }
  }
 
  updateInputValue(event, checkboxIndex) {
    var checkboxValues = {...this.state.checkboxValues}; 
 
    checkboxValues[checkboxIndex] = {
      'checked': !checkboxValues[checkboxIndex].checked, 
      'correctAnswer': !checkboxValues[checkboxIndex].checked ? event.target.value : null
    };

    this.setState({'checkboxValues': checkboxValues});
  } 

  submit() {
    this.getNextQuestion(); 
    var correctAnswer = Object.values(this.state.checkboxValues).filter(it => it.correctAnswer === 'true').length > 0;
    var wrongAnswer = Object.values(this.state.checkboxValues).filter(it => it.correctAnswer === 'false').length > 0;

    if (correctAnswer && !wrongAnswer) {
      this.setState(prevState => ({correct: prevState.correct + 1})); 
    }
  }

  render() {
    return (
      <div className="App"> 
        <header className="App-header">
          <p>Quiz:</p>
        </header>
          {this.state.question && this.state.alternatives ? (
            <div>
              <p>{this.state.question.question}</p>
              <input type="checkbox" id="checkboxOne" value={this.state.alternatives[0].correctAnswer} onChange={event => this.updateInputValue(event, 0)}/>
              <label htmlFor="checkboxOne">{this.state.alternatives[0].alternative}</label> 
              <br></br>
              <input type="checkbox" id="checkboxTwo" value={this.state.alternatives[1].correctAnswer} onChange={event => this.updateInputValue(event, 1)}/>
              <label htmlFor="checkboxTwo">{this.state.alternatives[1].alternative}</label>
              <br></br>
              <input type="checkbox" id="checkboxThree" value={this.state.alternatives[2].correctAnswer} onChange={event => this.updateInputValue(event, 2)}/>
              <label htmlFor="checkboxThree">{this.state.alternatives[2].alternative}</label>
              <br></br> 
              <button type="button" onClick={this.submit}>Svar</button>
            </div> 
          ) : (
              !this.state.done ? <p>Loading data...</p> : <p>Quizen er over! Du klarte å svare riktig på {this.state.correct} av {this.state.numberOfQuestions} spørsmål.</p>
          )}
        </div>
    ); 
  } 
}
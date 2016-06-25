import {Component} from 'angular2/core';
import {OnInit} from 'angular2/core';

@Component({
  selector: 'my-puzzle',
  template: `
    <section class="setup">
    <h2>Game setup:</h2>
      Enter your name please:
      <input type="text" #name (keyup)="0">
    </section>
    <section
    [ngClass]="{
      puzzle: true,
      solved: switch1.value == s1n && switch2.value == s2n && switch3.value == s3n && switch4.value == s4n
    }"
    [ngStyle]="{display: name.value === '' ? 'none' : 'block'}"
    >
      <h2>
        The Puzzle |
        {{switch1.value == s1n && switch2.value == s2n && switch3.value == s3n && switch4.value == s4n ? 'Solved' : 'Not solved'}}
      </h2>
      <p>Ok, welcome <span class="name">{{name.value}}</span></p>
      <br />
      Switch 1:
      <input type="text" #switch1 (keyup)="0"><br />
      Switch 2:
      <input type="text" #switch2 (keyup)="0"><br />
      Switch 3:
      <input type="text" #switch3 (keyup)="0"><br />
      Switch 4:
      <input type="text" #switch4 (keyup)="0"><br />
    </section>
    <h2 [hidden] = "switch1.value != s1n || switch2.value != s2n || switch3.value != s3n || switch4.value != s4n">Congratulations {{name.value}}, you did it!</h2>
  `
})

export class PuzzleComponent implements OnInit {
  s1n: number;
  s2n: number;
  s3n: number;
  s4n: number;

  ngOnInit() {
    this.s1n = Math.round(Math.random());
    this.s2n = Math.round(Math.random());
    this.s3n = Math.round(Math.random());
    this.s4n = Math.round(Math.random());
    console.log(this.s1n, this.s2n, this.s3n, this.s4n);
  }
}

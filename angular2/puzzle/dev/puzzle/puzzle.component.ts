import {Component} from 'angular2/core';

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
      <h2>The Puzzle</h2>
      <p>Ok, welcome <span class="name">XXX</span></p>
      <br />
      Switch 1:
      <input type="text" #switch1><br />
      Switch 2:
      <input type="text" #switch2><br />
      Switch 3:
      <input type="text" #switch3><br />
      Switch 4:
      <input type="text" #switch4><br />
    </section>
    <h2>Congratulations XXX, you did it!</h2>
  `
})

export class PuzzleComponent {
  s1n: number;
  s2n: number;
  s3n: number;
  s4n: number;
}

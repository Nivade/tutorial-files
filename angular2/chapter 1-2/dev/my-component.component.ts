import {Component} from 'angular2/core';
import {TestComponent} from "./test.component";
import {OnInit} from 'angular2/core';

@Component({
	selector: 'my-component',
	template: `
		<p>Hi, i'm <span [style.color]="inputElement.value === 'yes' ? 'red' : ''">{{name}}</span>.</p><br>
		<span [class.is-awesome]="inputElement.value === 'yes'">It's so awesome</span>
		Is it awesome?
		<input type="text" #inputElement (keyup)="0">
		<br/><br/>
		<button [disabled]="inputElement.value !== 'yes'" >only enabled if yes was entered</button>
	`,
	styleUrls: ['src/css/mycomponent.css'],
	directives: [TestComponent]
})

export class MyComponentComponent implements OnInit {
	name: string;
	
	ngOnInit():any {
		this.name = 'Niels';
	}
}

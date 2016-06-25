import {Component} from 'angular2/core';
import {MyComponentComponent} from "./my-component.component";


@Component({
    selector: 'my-app',
    template: `
        <h1>Who am i?</h1>
        <p>Hello World!</p>
		<p>Here comes the second component</p>
		<my-component></my-component>
    `,
	directives: [MyComponentComponent]
})

export class AppComponent {

}

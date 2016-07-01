import {Component} from 'angular2/core';

@Component({
    selector: 'my-app',
    template: `
        <input type="text" (keyup)="onKeyUp(inputElement.value)" #inputElement>
        <p>{{values}}</p>
    `,
})
export class AppComponent {
    values = '';

    onKeyUp(value: string) {
        this.values += value + ' | ';
    }
}

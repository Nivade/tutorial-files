import {Component} from 'angular2/core';

@Component({
    selector: 'my-app',
    template: `
        {{onTest()}}
        <input type="text" value="{{name}}">
    `,
})
export class AppComponent {
    name = 'Niels';
    onTest() {
        return 1 === 1;
    }

}

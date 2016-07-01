import { bootstrap } from '@angular/platform-browser-dynamic';
import { Component } from '@angular/core';

@Component({
  selector: 'hello-world',
  template: `
  <ul>
    <li *ngFor="let name of names">Hello {{ name }}</li>
  </ul>
  `
})

class HelloWorld {

  names: string[];

  constructor() {
    this.names = ['Niels', 'Harrie'];
  }

}

bootstrap(HelloWorld);

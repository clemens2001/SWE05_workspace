# BookShop

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 18.2.11.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The application will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via a platform of your choice. To use this command, you need to first add a package that implements end-to-end testing capabilities.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI Overview and Command Reference](https://angular.dev/tools/cli) page.


## Keycloak Docker Command

```docker run -p 8080:8080 -e KEYCLOAK_ADMIN=wea5admin -e KEYCLOAK_ADMIN_PASSWORD=wea5adminPass quay.io/keycloak/keycloak:26.0.5 start-dev```

### Keycloak Setup

http://localhost:8080

1. neues Realm anlegen "wea5"
2. neuen User anlegen "wea5user"
3. Speichern und unter Credentials Passwort anlegen "wea5userPass" Temporary "off"
4. Client anlegen "wea5-demo", "Implicit Flow" aktivieren, 
Root Url "http://localhost:4200", Valid Redirect Urls "http://localhost:4200/*", 
Web Origins "http://localhost:4200/*" und Save
5. 

## Passwort Identity Provider

Filip Pointer fragen

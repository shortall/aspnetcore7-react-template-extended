export class CssModuleNameComposer {
    styles: any;

    constructor(styles: any) {
        this.styles = styles;
    }

    composeNames = (classNames: Array<string>): string => {
        let returnValue = "";

        classNames.forEach((className, index) => {
            if (index > 0) {
                returnValue = returnValue + " ";
            }

            returnValue = returnValue + className;

            if (this.styles[className]) { 
                returnValue = returnValue + " " + this.styles[className];
            }
            
        });

        return returnValue;
    }
}
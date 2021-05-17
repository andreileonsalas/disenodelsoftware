class transportePesado {
    constructor(props) {
        this.combustible = props.combustible;
        this.cantidadPersonasTransporar = props.cantidadPersonasTransporar;
    }
};

class transporteAutomovil {
    constructor(props) {
        this.combustible = props.combustible;
        this.cantidadPersonasTransporar = props.cantidadPersonasTransporar;
    }
};

class transporteBus {
    constructor(props) {
        this.combustible = props.combustible;
        this.cantidadPersonasTransporar = props.cantidadPersonasTransporar;
    }
};

class transporteFactory {
    constructor(type, props) {
        if (type === "pesado")
            return new transportePesado(props);
        if (type === "automovil")
            return new transporteAutomovil(props);
        if (type === "bus")
            return new transporteBus(props);
    }
};

let transportes = {};
let transportesArray = [];
let transportePropsAutomovil = {
    combustible: 2,
    cantidadPersonasTransporar: 4,
};
let transportePropsPesado = {
    combustible: 10,
    cantidadPersonasTransporar: 2,
};
let transportePropsBus = {
    combustible: 5,
    cantidadPersonasTransporar: 20,
};

transportes.pesado = new transporteFactory("pesado", transportePropsPesado);
transportes.automovil = new transporteFactory("automovil", transportePropsAutomovil);
transportes.bus = new transporteFactory("bus", transportePropsBus);
transportesArray.push(new transporteFactory("pesado", transportePropsPesado));
transportesArray.push(new transporteFactory("automovil", transportePropsAutomovil));
transportesArray.push(new transporteFactory("bus", transportePropsBus));


console.log(transportes);


for (let index = 0; index < transportesArray.length; index++) {
    console.log(transportesArray[index]);
}

//object pool
//mediador

var spinnerVisible = false;

class CompanyController {    

    #divListas;
    #spinner;
    #divConteudosEmpresa;


    constructor() {
        this.#divListas = $('#divListas');
        this.#spinner = $('#spinner');
        this.#divConteudosEmpresa = $('#divConteudosEmpresa');
    }



    mostrarSpinner() {
        if (!spinnerVisible) {
            this.#spinner.fadeIn();
            spinnerVisible = true;
        }
    }

    esconderSpinner() {
        if (spinnerVisible) {
            this.#spinner.stop();
            this.#spinner.fadeOut();
            spinnerVisible = false;
        }
    }

    carregarEmpresas(url) {

        this.mostrarSpinner();

        this.#divListas.load(url, () => {
            this.esconderSpinner();
        });
    }

    mostrarDados(url) {

        this.mostrarSpinner();    

        this.#divConteudosEmpresa.load(url, () => {
            this.esconderSpinner();
        });
    }

    fecharDiv() {
        this.#divConteudosEmpresa.empty();
    }

    exportarExcel(url) {
        window.open(url);
    }
}
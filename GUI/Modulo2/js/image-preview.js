$(document).on('change', '.btn-file :file', function () {

    /*
     * Declaración de variables
     *
     * - input: componente que dispara el evento .on('change')
     * - numFiles: obtiene la cantidad de archivos que han sido subidos (se limitó a
     *   uno al quitar el atributo 'multiple')
     * - label: captura del nombre de la imagen a ser subida
     */
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');

    /* Dispara el trigger 'fileselect' con los atributos numFiles y label */
    input.trigger('fileselect', [numFiles, label]);

});

$(document).ready(function () {

    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {

        /* 
         * Consulta el parámetro numFiles para determinar el texto de salida
         * (La carga se limitó a una sola imagen)
         */
        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' Archivos seleccionados' : label;

        /* Comprobación de error para input.lenght */
        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });

    function getURL(input) {

        /* Verificamos la existencia de archivos en el componente input */
        if (input.files && input.files[0]) {

            /* Inicializamos un objeto de clase FileReader() */
            var reader = new FileReader();

            /*
             * Asignamos la imagen al atributo src
             * (onLoad() garantiza que la imagen se visualizará después de haber sido cargado por completo)
             */
            reader.onload = function(e) {
                $('.img-thumbnail').attr('src', e.target.result);
            }

            /* Indicamos cómo debe de ser interpretada la imagen */
            reader.readAsDataURL(input.files[0]);

        }
    }

    $(".imagen-url").change(function () {
        /* Al ocurrir un cambio en la imagen seleccionada, se ejecutará la función getURL() */
        getURL(this);
    });

});
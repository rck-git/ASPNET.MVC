document.addEventListener('DOMContentLoaded', function () {

    handleProfileImageUpload()
})

function handleProfileImageUpload() {
    try {
        let fileUploader = document.querySelector('#fileUploader')
        if (fileUploader != undefined) {
            console.log('inne')
            fileUploader.addEventListener('change', function () {
                if (this.files.length > 0) {
                    this.form.submit()
                }
            })
        }

    }
    catch (e) {

    }

}
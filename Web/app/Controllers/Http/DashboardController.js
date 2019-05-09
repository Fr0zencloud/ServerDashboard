'use strict'

const Service = use('App/Models/Service')

class DashboardController {

    async index({ view }) {
        let services = (await Service.all()).toJSON()

        return view.render('dashboard', {
            services: services
        })
    }

}

module.exports = DashboardController

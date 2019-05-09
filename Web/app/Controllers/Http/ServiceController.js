'use strict'

const Service = use('App/Models/Service')

class ServiceController {

    async store({ request, session, response }) {
        const service = new Service()
        service.title = request.input('title')
        service.icon = request.input('icon')
        await service.save()

        session.flash({ notification: 'Service created' })
        
        return response.redirect('back')
    }

    async delete() {
        const service = await Service.find(params.id)
        await service.delete()

        session.flash({ notification: 'Service deleted'})

        return response.redirect('back')
    }
}

module.exports = ServiceController

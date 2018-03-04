function notify (notification) {
  if (!notification) return
  const elem = document.createElement('div')

  const badge = notification.badge ? `<div class="uk-card-badge uk-label notification__badge">${notification.badge}</div>` : ''
  const icon = `<div class="notification__icon mdi ${notification.icon ? notification.icon : 'mdi-bell'}"></div>`
  const title = `<h3 class="uk-card-title notification__title">${notification.title ? notification.title : 'Notification'}</h3>`
  const content = notification.content ? notification.content : 'No content avaliable'

  elem.innerHTML = `
  <div class="uk-card uk-card-default uk-card-small notification">
    ${badge}
    <div class="uk-card-header notification__header">
      ${icon}
      ${title}
    </div>
    <div class="uk-card-body notification__body">
      <p>${content}</p>
    </div>
  </div>
`

  document.body.appendChild(elem)

  setTimeout(() => {
    document.body.removeChild(elem)
  }, 6000)
}

window.onload = () => {
  console.log('Exported')
  window.exports = {notify}
}

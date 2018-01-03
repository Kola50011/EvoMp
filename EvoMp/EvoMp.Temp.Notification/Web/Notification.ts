/// <reference path="../../typings/index.d.ts" />

// Tell the client, that you're ready to recieve notifications.
document.addEventListener('DOMContentLoaded', () => {
  // resourceEval(`resource.CefEventHandlerSingleton.trigger('Notification.load', [])`)
})

function notify(icon: string, message: string, color: string): void {
  let notification: HTMLLIElement = document.createElement('li')
  notification.classList.add('notification')
  notification.innerHTML = `<div class="icon" style="background-color: ${color}">
                              <i class="${icon}"></i>
                            </div>
                            <div class="content">
                              <span class="message">${gtaFontToHtml(
                                message
                              )}</span>
                            </div>
                            <div class="time"></div>`

  if (document.querySelector('#notification-list') !== null) {
    document.querySelector('#notification-list')!.appendChild(notification)
  }

  setTimeout(() => {
    if (document.querySelector('#notification-list') !== null) {
      document.querySelector('#notification-list')!.removeChild(notification)
    }
  }, 4950)
}

function gtaFontToHtml(gtaFontString: string) {
  let spanString = '<span class="%s">'
  let colors: [
    {
      gtaFont: string
      htmlWrapperStart: string
      htmlWrapperend: string
      cssClass: string
    }
  ] = [
    {
      gtaFont: '~r~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontRed'
    },
    {
      gtaFont: '~b~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontBlue'
    },
    {
      gtaFont: '~g~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontGreen'
    },
    {
      gtaFont: '~y~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontYellow'
    },
    {
      gtaFont: '~p~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontPurple'
    },
    {
      gtaFont: '~o~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontOrange'
    },
    {
      gtaFont: '~c~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontGrey'
    },
    {
      gtaFont: '~m~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontDarkerGrey'
    },
    {
      gtaFont: '~u~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontBlack'
    },
    {
      gtaFont: '~n~',
      htmlWrapperStart: '<br>',
      htmlWrapperend: '',
      cssClass: 'gtaFontNewLine'
    },
    {
      gtaFont: '~s~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontDefaultWhite'
    },
    {
      gtaFont: '~w~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontWhite'
    },
    {
      gtaFont: '~h~',
      htmlWrapperStart: spanString,
      htmlWrapperend: '</span>',
      cssClass: 'gtaFontBoldText'
    }
  ]

  let colorsCloseHtmlList: any[] = new Array<any>()
  for (let color in colors) {
    let currentColor: any = colors[color]
    while (gtaFontString.indexOf(currentColor['gtaFont']) > -1) {
      gtaFontString = gtaFontString.replace(
        currentColor['gtaFont'],
        currentColor['htmlWrapperStart'].replace('%s', currentColor['cssClass'])
      )
      colorsCloseHtmlList.push(currentColor)
    }
  }
  for (let closeColor in colorsCloseHtmlList) {
    gtaFontString =
      gtaFontString + colorsCloseHtmlList[closeColor]['htmlWrapperend']
  }
  return gtaFontString
}

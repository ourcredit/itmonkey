import {
  ASYNC_UPDATE
} from '../types/userState'
import {
  createAction
} from 'redux-actions'

export const asyncInc = createAction(ASYNC_UPDATE, () => {
  return new Promise(resolve => {
    setTimeout(() => {
      resolve(1)
    }, 1000)
  })
})

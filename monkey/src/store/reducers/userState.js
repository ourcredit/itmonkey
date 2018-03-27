import {
  handleActions
} from 'redux-actions'
import {
  UPDATE,
  REGISTER,
  CHATID
} from '../types/userState'

export default handleActions({
  [UPDATE](state, action = {}) {
    return { ...state,
      user: action.model
    }
  },
  [REGISTER](state, action = {}) {
    return {
      ...state,
      hasRegister: action.model
    }
  },
  [CHATID](state, action = {}) {
    return {
      ...state,
      chatId: action.model
    }
  }
}, {
  user: null,
  hasRegister: false,
  chatId: null
})

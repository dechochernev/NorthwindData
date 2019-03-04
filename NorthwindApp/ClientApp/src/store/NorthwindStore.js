const receiveNorthwindRegionsType = 'RECEIVE_NORTHWINDREGIONS';
const requestTerritoriesForRegion = 'REQUEST_TERRITORIESFORREGIONS';
const requestEmployeesForTerritory = 'REQUEST_EMPLOYEESFORTERRITORY';
const initialState = { regions: [], territories: [], employees: [], currentRegionId: 0, currentRegionName:'', isLoading: false };

export const actionCreators = {
    requestRegions: () => async (dispatch) => {
        const url = `api/Regions/GetAllRegionsAsync`;

        const response = await fetch(url);
        const regions = await response.json();

        dispatch({ type: receiveNorthwindRegionsType, regions });
    },
    requestTerritoriesForRegion: regionId => async (dispatch) => {
        const url = `api/Regions/GetTerritoriesForRegionAsync?regionId=${regionId}`;

        const response = await fetch(url);
        const territories = await response.json();
        dispatch({ type: requestTerritoriesForRegion, territories, regionId });
    },
    requestEmployeesForTerritory: territoryId => async (dispatch) => {
        const url = `api/Regions/GetEmployeesForTerritoryAsync?territoryId=${territoryId}`;

        const response = await fetch(url);
        const employees = await response.json();
        dispatch({ type: requestEmployeesForTerritory, employees});
    },
    UpdateEmployeeNotes: (employeeId, notes, territoryId) => async (dispatch) => {
        const url = `api/Regions/UpdateEmployeeNotesAsync?employeeId=${employeeId}&notes=${notes}`;
        const response = await fetch(url, {method: 'post'});
        const employees = await response.text();
        dispatch(actionCreators.requestEmployeesForTerritory(territoryId));
    }
};

export const reducer = (state, action) => {
    state = state || initialState;

    if (action.type === receiveNorthwindRegionsType) {
        return {
            ...state,
            regions: action.regions,
            isLoading: false
        };
    }

    if (action.type === requestTerritoriesForRegion) {
        return {
            ...state,
            territories: action.territories
        };
    }

    if (action.type === requestEmployeesForTerritory) {
        return {
            ...state,
            employees: action.employees
        };
    }

    return state;
};
